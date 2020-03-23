namespace EruMobileScooter.Service.Helpers
{
    public static class Helper
    {
        
        public static bool isNullOrEmpty(string str){
            if(str.Equals("") || str == null)
                return true;
            else
                return false;
        }
        
    }
}