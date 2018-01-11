///-------------------<>----------------///
///     Author: Gabby_NG                ///
///       Date: 15 July                 ///
///    Project: SU_33_Flanker_D         ///
///       File: extension.sqf           ///
/// Permission: GPL v3.0                ///
///-------------------<>----------------///
disableSerialization;

private ["_plane","_control","_x_axis","_z_axis","_return","_index","_service","_return_array","_axis_out","_string","_string_out"];

_plane = _this select 0;
//_plane = _this;
_control = true;
_service = true;
_return = "true";
while{_control} do
{
    if(isEngineOn _plane) then
    {
        hint "Uçuş kontrolları yapılıyor";
        _return ="Open_Client" callExtension "status";
        _return_array = _return splitString " ";
        _index = _return_array find "Stopped";
        while{_service}do
        {
            if(_index!=-1)then
            {
                _return = _return_array select _index;
            }
            else
            {
                _return ="Open_Client" callExtension "stop";
                sleep 2;
                hint "Not found";
            };
        };


        /*_control = false;
        hintSilent "Bağlantı isteği yollandı";*/

        /*if(_return=="true") then
        {
           hintSilent "Makine ile bağlantı kuruluyor.....";
           sleep 3;
           _return ="SM_Client" callExtension "Baglanti istegi geldi";// add com adress
           hintSilent "Uçak Hazır";//"CONNECTED";
           sleep 5;

           while {(alive _plane) and (isEngineOn _plane) } do
           {
               // get new radian numbers for x and z axis
               _x_axis = _plane animationSourcePhase  "horizonDive";
               _z_axis = _plane animationSourcePhase  "horizonBank";

               //Convert new number from Radians to Degrees.
               _x_axis = (deg _x_axis)*(-1);
               _z_axis = (deg _z_axis)*(-1);
                sleep 0.05;
               _axis =
               [
                 _x_axis,
                _z_axis
               ];
               _string = _axis joinString "/"; // String: x/z

               _axis_out =
               [
                "X:",
                round _x_axis,
                "Z:",
                round _z_axis
               ];
               _string_out =_axis_out joinString "/";
               if((_x_axis<90) and (_x_axis>-90) or (_z_axis<90) and (_z_axis>-90))then
               {
                _return ="SM_Client" callExtension _string;
                systemChat _string;
               }
               else
               {
                    systemChat _string_out;
               };

           };
        }
        else
        {
            hintSilent "System can not started";
        };*/
    }
    else
    {
        hintSilent "Uçak motoru çalışmaya başladığında, şase hazır hale otomatik gelecektir";
    };
};
/*if((_old_x_axis != _x_axis) or (_old_z_axis != _z_axis))then
{
     systemChat _string_out
   if((_x_axis<90) and (_x_axis>-90) or (_z_axis<90) and (_z_axis>-90))then
   {
    _return ="SM_Client" callExtension _string;
    hintSilent _string;
   };
};*/

