
///-------------------<>----------------///
///     Author: Gabby_NG                ///
///       Date: 21 August               ///
///    Project: SU_33_Flanker_D         ///
///       File: gui_com_list.sqf        ///
/// Permission: GPL v3.0                ///
///-------------------<>----------------///
disableSerialization;

private ["_COM_LISt","_ctrl"];

_COM_LISt = ["COM1", "COM2"];

createDialog "COM_LIST_HARDWARE";

waitUntil {!isNull(findDisplay 9999);};

_ctrl = (findDisplay 9999) displayCtrl 1500;

{

 _ctrl lbAdd _x;

}forEach _COM_LISt;