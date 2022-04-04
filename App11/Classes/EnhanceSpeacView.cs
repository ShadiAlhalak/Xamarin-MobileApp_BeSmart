namespace App11.Classes
{
    public class EnhanceSpeacView

    {
        public static clsFullSpeac Display(MobileSpaceObject mob)
        {
            string type = mob.Display_Type;
            string Size = mob.Display_Size;
            string Resolution = mob.Display_Resolution;
            string Protection = mob.Display_Protection;
            clsFullSpeac screen = new clsFullSpeac("DISPLAY", "Type", "Size", "Resolution", "Protection", mob.Display_Type, mob.Display_Size, mob.Display_Resolution, mob.Display_Protection);
            return screen;
        }
    }
}