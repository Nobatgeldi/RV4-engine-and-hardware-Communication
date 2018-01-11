///-------------------<>----------------///
///     Author: Gabby_NG                ///
///       Date: 15 July                 ///
///    Project: SU_33_Flanker_D         ///
///       File: extension.sqf           ///
/// Permission: GPL v3.0                ///
///-------------------<>----------------///
disableSerialization;

private ["_plane","_control","_x_axis","_z_axis","_old_x_axis","_old_z_axis","_old_x","_old_z","_return","_string_x","_string_z","_string",
"_velocity_x","_velocity_z","_direction_x","_direction_z","_x_axis_out","_z_axis_out"];

_plane = _this select 0;
_control = true;
_string_x="0/0/0";
_string_z="0/0/0";
_string="0/0/0*0/0/0";
_old_x=0;
_old_z=0;

while{_control} do
{
    if(isEngineOn _plane) then
    {
        _return ="Open_Client" callExtension "open";
        _control = false;
        hintSilent _return;
    }
    else
    {
        hintSilent "Uçak motoru çalışmaya başladığında, şase hazır hale otomatik gelecektir";
    };
};

if(_return=="true") then
{
   hintSilent "Makine ile bağlantı kuruluyor.....";
   sleep 5;

   _return ="SM_Client" callExtension "Harekete Hazir";// add com adress
   hintSilent "Harekete Hazır";//_return; "CONNECTED";
   sleep 5;

   while {(alive _plane) and (isEngineOn _plane) } do
   {
      // get radian numbers for x and z axis
       _x_axis = _plane animationSourcePhase  "horizonDive";
       _z_axis = _plane animationSourcePhase  "horizonBank";

       //Convert a number from Radians to Degrees.
       _x_axis = round (deg _x_axis);
       _z_axis = round (deg _z_axis);

           _old_x_axis = _x_axis;
           _old_z_axis = _z_axis;
            sleep 0.1;

       // get new radian numbers for x and z axis
       _x_axis = _plane animationSourcePhase  "horizonDive";
       _z_axis = _plane animationSourcePhase  "horizonBank";

       //Convert new number from Radians to Degrees.
       _x_axis = round (deg _x_axis);
       _z_axis = round (deg _z_axis);


       if((_old_x_axis != _x_axis)or (_old_z_axis != _z_axis))then
       {
           _angly =
           [
              _x_axis,
              _z_axis
           ];
           systemChat (_angly joinString "/");

           if(_old_x_axis != _x_axis)then
           {
                // find how much to rotate
                _x_axis_out =_x_axis - _old_x;
                /// find how much to speed and direction
                if(_x_axis_out>0) then
                {
                    _direction_x = 1;
                    _velocity_x = _x_axis_out/0.1;
                }
                else
                {
                    if(_x_axis_out<0) then
                    {
                        _direction_x = (-1);
                        _velocity_x = (_x_axis_out*(-1))/0.1;
                    }
                    else
                    {
                        _direction_x = 0;
                        _velocity_x = 0;
                    };
                };
                _old_x=_x_axis;
                // add to array and create array
                _axis_x =
                [
                  _x_axis_out,
                  _direction_x,
                  _velocity_x
                ];
                _string_x = _axis_x joinString "/";
           }
           else
           {
            _string_x="0/0/0";
           };
           if(_old_z_axis != _z_axis)then
           {
               // find how much to rotate
               _z_axis_out =_z_axis - _old_z;
               /// find how much to speed and direction
               if(_z_axis_out>0) then
               {
                   _direction_z = 1;
                   _velocity_z = _z_axis_out/0.1;
               }
               else
               {
                   if(_z_axis_out<0) then
                   {
                       _direction_z = (-1);
                       _velocity_z = (_z_axis_out*(-1))/0.1;
                   }
                   else
                   {
                       _direction_z = 0;
                       _velocity_z = 0;
                   };
               };
               _old_z=_z_axis;
               // add to array and create array
               _axis_z =
               [
                 _z_axis_out,
                 _direction_z,
                 _velocity_z
               ];
               _string_z = _axis_z joinString "/";
           }
           else
           {
            _string_z="0/0/0";
           };
           _axis =
           [
            _string_x,
            _string_z
           ];
          _string = _axis joinString "*"; // String: x/y
          hintSilent _string;
          _return ="SM_Client" callExtension _string;
       }
       else
       {
          _string="0/0/0*0/0/0";
          _return ="SM_Client" callExtension _string;
          hintSilent _string;
       };
   };
}
else
{
    hintSilent "System can not started";
};

