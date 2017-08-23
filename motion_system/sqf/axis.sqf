
///-------------------<>----------------///
///     Author: Gabby_NG                ///
///       Date: 15 July                 ///
///    Project: SU_33_Flanker_D         ///
///       File: axis.sqf                ///
/// Permission: GPL v3.0                ///
///-------------------<>----------------///
disableSerialization;

private ["_plane","_com","_COM_LIST","_selected_com","_BUTTON","_button_control",
"_selected","_control","_ctrl","_x_axis","_y_axis","_z_axis","_old_x_axis","_old_y_axis","_old_z_axis","_return"];

_plane = _this;
_control=true;

_return ="Serial_Port_List" callExtension "connection";

_COM_LIST = [];
_COM_LIST = _return splitString "/";

_BUTTON = ["FREE","CONNECT","START"];

createDialog "COM_LIST_HARDWARE";

waitUntil {!isNull(findDisplay 9999);};

//list box configuration
_ctrl = (findDisplay 9999) displayCtrl 1500;

{

 _ctrl lbAdd _x;

}forEach _COM_LIST;

//button configuration
_button_control = (findDisplay 9999) displayCtrl 1501;

{

 _button_control lbAdd _x;

}forEach _BUTTON;
while{_control} do
{
    _selected = lbCurSel _button_control;//Returns the index of the selected item of
                                         //the listbox or combobox with id idc of the topmost user dialog.
                                         //For listbox LB_MULTI (multi-selection) use lbSelection.
    if(_selected==1) then
    {
        //get selected adress from list box
        _selected_com = lbCurSel _ctrl;
        //get string of adress from array
        _com = _COM_LIST select _selected_com;
        /*hintSilent _com;
        sleep 2;*/
        hintSilent "Testing Connection";
        _return ="Serial_Port_List" callExtension _com;// add com adress
        sleep 1;
        if(_return == "succeed")then
        {
            hintSilent "Succeed";// show that it is correct device
        }
        else
        {
            hintSilent _return;
        };
        sleep 3;
    };
    if(_selected==2)then
    {
       //get selected adress from list box
       _selected_com = lbCurSel _ctrl;
       //get string of adress from array
       _com = _COM_LIST select _selected_com;

       hintSilent "Starting to connect";
       sleep 2;

       _return ="Serial_Port_List" callExtension "ALL_lights";// add com adress
       hintSilent _return;//"CONNECTED";

       while {(alive _plane)} do
       {
          // get radian numbers for x and z axis
           _x_axis = _plane animationPhase  "horizonDive";
           _z_axis = _plane animationPhase  "horizonBank";

           //Convert a number from Radians to Degrees.
           _x_axis = round (deg _x_axis);
           _y_axis = round (getDir _plane);
           _z_axis = round (deg _z_axis);

               _old_x_axis = _x_axis;
               _old_y_axis = _y_axis;
               _old_z_axis = _z_axis;

               sleep 0.1;

               _x_axis = _plane animationPhase  "horizonDive";
               _z_axis = _plane animationPhase  "horizonBank";

               _x_axis = round (deg _x_axis);
               _y_axis = round (getDir _plane);
               _z_axis = round (deg _z_axis);

           if((_old_y_axis != _y_axis) or (_old_x_axis != _x_axis) or (_old_z_axis != _z_axis))then
           {
               if(_old_y_axis != _y_axis)then
               {
                    _return ="Nobat_ext" callExtension "y";
               };
               if(_old_x_axis != _x_axis)then
               {
                    _return ="Nobat_ext" callExtension "x";
               };
               if(_old_z_axis != _z_axis)then
               {
                    _return ="Nobat_ext" callExtension "z";
               };
           }
           else
           {
               _return ="Nobat_ext" callExtension "2";
           };
           _axis =
           [
            _return,
            _y_axis,
            _x_axis,
            _z_axis
           ];
           _string = _axis joinString "/"; //  360/180/180
           hintSilent _string;
       };
       _control= false;
    }
    else
    {
        hintSilent "FREE";
    };
};
