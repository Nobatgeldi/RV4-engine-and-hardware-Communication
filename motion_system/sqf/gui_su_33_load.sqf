
///-------------------<>----------------///
///     Author: Gabby_NG                ///
///       Date: 24 August               ///
///    Project: SU_33_Flanker_D         ///
///       File: gui_su_33_load.sqf      ///
/// Permission: GPL v3.0                ///
///-------------------<>----------------///
disableSerialization;
private ["_display","_button_ctrl","_button","_R73_missile","_selected","_control","_R_wing_1"];

_display = findDisplay 9998;
_button = ["LOAD", "CLOSE"];
_R73_missile = ["magazine_Missile_AA_R73_x1", "PylonMissile_Missile_AA_R73_x1"];

createDialog "SU_33_LOAD";

waitUntil {!isNull _display;};

_button_ctrl = _display displayCtrl 1500;
{
 _button_ctrl lbAdd _x;
}forEach _button;

_R_wing_1 = _display displayCtrl 2100;
{
 _R_wing_1 lbAdd _x;
}forEach _R73_missile;

_control=true;
/*while{_control} do
{
    _selected = lbCurSel _button_ctrl;

    if(_selected==1) then
    {};
};*/
