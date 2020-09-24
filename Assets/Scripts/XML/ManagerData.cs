// ManagerData is our custom class that holds our defined objects we want to store in XML format 

public struct Fuck
{
    public int finger;
    public int midfinger;
}

 public class ManagerData 
 { 
    // We have to define a default instance of the structure 
   public Data manage;
    // Default constructor doesn't really do anything at the moment 
   public ManagerData() { } 
   

 
   // 관리할것들
   public struct Data 
   {
       public int Coin;
       public bool bGiftCoin;
       public int ItemTimeUpgradeLevel;
       public int ItemFastShowUpgradeLevel;
       public int FastStartUpgradeLevel;
       public int HighScore;
       public int rank_1;
       public int rank_2;
       public int rank_3;
       public int rank_4;
       public int rank_5;
   }
}
