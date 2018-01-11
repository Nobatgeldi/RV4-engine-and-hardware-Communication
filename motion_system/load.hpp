
class SU_33_LOAD
{
    idd = 9998;
    movingEnabled = false;
    class controls
    {
        ////////////////////////////////////////////////////////
        // GUI EDITOR OUTPUT START (by Nobat, v1.063, #Devede)
        ////////////////////////////////////////////////////////

        class Frame: RscPicture
        {
        	idc = 1200;
        	text = "\SU_33_Flanker_D\tex\UI\Pylon.paa";
        	x = 0.190104 * safezoneW + safezoneX;
        	y = 0.194 * safezoneH + safezoneY;
        	w = 0.6375 * safezoneW;
        	h = 0.527 * safezoneH;
        };

        class R_wing_1: RscCombo
        {
        	idc = 2100;
        	x = 0.198958 * safezoneW + safezoneX;
        	y = 0.449 * safezoneH + safezoneY;
        	w = 0.0796875 * safezoneW;
        	h = 0.034 * safezoneH;
        };
        class R_wing_2: RscCombo
        {
            idc = 2108;
            x = 0.269792 * safezoneW + safezoneX;
            y = 0.5 * safezoneH + safezoneY;
            w = 0.0796875 * safezoneW;
            h = 0.034 * safezoneH;
        };
        class R_wing_3: RscCombo
        {
        	idc = 2101;
        	x = 0.331771 * safezoneW + safezoneX;
        	y = 0.449 * safezoneH + safezoneY;
        	w = 0.0708333 * safezoneW;
        	h = 0.034 * safezoneH;
        };

        class Engine_R: RscCombo
        {
        	idc = 2102;
        	x = 0.420312 * safezoneW + safezoneX;
        	y = 0.534 * safezoneH + safezoneY;
        	w = 0.0796875 * safezoneW;
        	h = 0.034 * safezoneH;
        };
        class Engine_L: RscCombo
        {
        	idc = 2103;
        	x = 0.517708 * safezoneW + safezoneX;
        	y = 0.534 * safezoneH + safezoneY;
        	w = 0.0796875 * safezoneW;
        	h = 0.034 * safezoneH;
        };

        class L_wing_1: RscCombo
        {
            idc = 2105;
            x = 0.739062 * safezoneW + safezoneX;
            y = 0.449 * safezoneH + safezoneY;
            w = 0.0708333 * safezoneW;
            h = 0.034 * safezoneH;
        };
        class L_wing_2: RscCombo
        {
            idc = 2109;
            x = 0.677083 * safezoneW + safezoneX;
            y = 0.5 * safezoneH + safezoneY;
            w = 0.0708333 * safezoneW;
            h = 0.034 * safezoneH;
        };
        class L_wing_3: RscCombo
        {
        	idc = 2104;
        	x = 0.615104 * safezoneW + safezoneX;
        	y = 0.449 * safezoneH + safezoneY;
        	w = 0.0708333 * safezoneW;
        	h = 0.034 * safezoneH;
        };

        class Mid_F: RscCombo
        {
        	idc = 2106;
        	x = 0.473437 * safezoneW + safezoneX;
        	y = 0.585 * safezoneH + safezoneY;
        	w = 0.0708333 * safezoneW;
        	h = 0.034 * safezoneH;
        };
        class Mid_R: RscCombo
        {
        	idc = 2107;
        	x = 0.473437 * safezoneW + safezoneX;
        	y = 0.636 * safezoneH + safezoneY;
        	w = 0.0708333 * safezoneW;
        	h = 0.034 * safezoneH;
        };

        class Machine_GUN: RscCombo
        {
        	idc = 2110;
        	x = 0.376042 * safezoneW + safezoneX;
        	y = 0.381 * safezoneH + safezoneY;
        	w = 0.0796875 * safezoneW;
        	h = 0.034 * safezoneH;
        };
        class ACCEPT: RscListbox
        {
        	idc = 1500;
        	x = 0.685937 * safezoneW + safezoneX;
        	y = 0.602 * safezoneH + safezoneY;
        	w = 0.123958 * safezoneW;
        	h = 0.068 * safezoneH;
        };
        ////////////////////////////////////////////////////////
        // GUI EDITOR OUTPUT END
        ////////////////////////////////////////////////////////



    };
};