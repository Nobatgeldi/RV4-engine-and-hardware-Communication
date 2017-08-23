
class COM_LIST_HARDWARE
{
    idd = 9999;
    movingEnabled = false;
    class controls
    {
        ////////////////////////////////////////////////////////
        // GUI EDITOR OUTPUT START (by Nobat, v1.063, #Naduno)
        ////////////////////////////////////////////////////////

        class COM_LIST_FRAME: RscPicture
        {
            idc = 1200;
            text = "#(argb,8,8,3)color(0,0,1,0.5)";
            x = 0.322894 * safezoneW + safezoneX;
            y = 0.210987 * safezoneH + safezoneY;
            w = 0.398488 * safezoneW;
            h = 0.629029 * safezoneH;
        };
        class COM_LIST: RscListbox
        {
            idc = 1500;
            text = "BAĞLI DONANIM LİSTESİ"; //--- ToDo: Localize;
            x = 0.358316 * safezoneW + safezoneX;
            y = 0.346993 * safezoneH + safezoneY;
            w = 0.132829 * safezoneW;
            h = 0.323015 * safezoneH;
            onLBSelChanged = "systemChat str ['Selected',_this]; false";
        };
        class BUTTON: RscListbox
        {
            idc = 1501;
            text = "BUTTON"; //--- ToDo: Localize;
            x = 0.535421 * safezoneW + safezoneX;
            y = 0.465998 * safezoneH + safezoneY;
            w = 0.15054 * safezoneW;
            h = 0.15 * safezoneH;
            onLBSelChanged = "systemChat str ['Selected',_this]; false";
        };
        ////////////////////////////////////////////////////////
        // GUI EDITOR OUTPUT END
        ////////////////////////////////////////////////////////

    };
};

