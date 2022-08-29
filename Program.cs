    
        public class Player{
            /*
            Player One  --- NUmber == 1 disc = X
            Player Two  ----Number ===2 disc == O
            */
            public int id;
            public string disc ="";
            public Player(int _id, string _disc){
                id = _id;
                disc = _disc;
            }
            
        }
    class Game{
        private int CurrentX; /// variable whose data is from the user the column they choose to drop their disc in
        private int CurrentY;
        public int playernum;
        private String WinStatus = "NA";
   
    
        private String winStatus {
            get{return WinStatus;}
            set{WinStatus = value;}
        }
        private String PlayMode = "NotPlayed";
   
        private static Player player2= new Player(2,"O");
        private static Player player1= new Player(1,"X");
        Player player = player2;
      
        
        
        //Intialize a 6 X 7 matrix
        string [,]array= new string[6,7] {
            {"#","#","#","#","#","#","#"},
            {"#","#","#","#","#","#","#"},
            {"#","#","#","#","#","#","#"},
            {"#","#","#","#","#","#","#"},
            {"#","#","#","#","#","#","#"},
            {"#","#","#","#","#","#","#"}
        };

        
          
        
        private int GameMode = 2;   //2-player Mode or 1-player Mode

        public int gamemode{
            get{return GameMode;}
            set{GameMode = value;}
        }
        public void DisplayGame(){
                Console.WriteLine("\n|   1     2     3     4     5     6     7   |");
           for(int i =0;i<6;i++){
                //Rember to Number the Columns and Rows 
                Console.WriteLine("|   {0}      {1}     {2}     {3}     {4}     {5}     {6}  | ",array[i,0], array[i,1],array[i,2],array[i,3],array[i,4],array[i,5],array[i,6]);        
           }
        }
        public String PlayGame(String [,]array ){
            //User enters column number to enter the disc
            Console.WriteLine("Enter the column number to place disc at ");
            
            int column = 0;
            String col ;
           
            col = Console.ReadLine();
            if(col != null){
                try{
                column =int.Parse( col);
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                }
            }
               
        
            
            if(column > 6 | column < 0){
                Console.WriteLine("Enter a Valid column\n");
                PlayGame(array);
            }
            CurrentX = column;

            //Change the player that's playing 
            //Console.WriteLine("Line 77 after for loop  {0}", column);
            //start checking the last row if there is any disc 
            int j =0;
            for(int i=5; i >0; i-- ){
                 
                //if slot is not filled enter disc
                if(j> 0){break;}
               
                if(array[i,column] == "#"){
                   
                    array[i,column] = player.disc;
                    CurrentY =  i; 
                    CurrentX =  column;                      
                    PlayMode = "Played";
                    j++;
                     
                }else if(array[0,column] != "#"){
                    Console.WriteLine("Enter  a different column");
                    //PlayGame(array);
                    PlayMode = "Columnisfull";
                    
                }
               }
            return PlayMode;
        }
        
        public void GameSettings(){

            //Function to get user input to see whether the users want to play against their teammate or AI
            Console.WriteLine("Enter the gameMode ?\n");
            Console.WriteLine("1. Play agasint Our Cool AI");
            Console.WriteLine("2. Play against your oponent");

            //FUNCTION 
            int gmode =int.Parse( Console.ReadLine() );

            if(gmode == 1){
                GameMode = gmode;
            }else if (gmode ==2){
                GameMode = gmode;
            }else{
                Console.WriteLine("Enter the right settings\n");
                GameSettings();
            }

            return; 
          
            
        }
        public String CalculateWinHN(String [,]array,Player player,int CurrentX,int CurrentY){
        
            //Function to check if the lhs  to the current played point is a win
            int i =0, j = 0;
            while(i<7){
           
            if( (CurrentX-j) < 0 ){
                return WinStatus = "ContinuePlaying";
               
            }
            if(array[CurrentY,CurrentX-j] == player.disc){
                 j++;
                if(j>=4){
                     Console.WriteLine("GAME OVER PLAYER {0} HAS WON ",player.id);
                    return WinStatus = "Win";

                }
            }
            i++;
            
             //Console.WriteLine("calculateWinHN {0}      {1}     {2}",array[CurrentY,CurrentX-i],player.disc,e);
            }
           return WinStatus;
             
             
        }
        public String CalculateWinHP(String [,]array,Player player,int CurrentX,int CurrenametY){
            int i =0, j = 0;
            while(i<7){
            //code to avoid for IndexOutOFRange Errors
             if(CurrentX+j > 6 ){
                return WinStatus = "ContinuePlaying";   
            }
            
             if(array[CurrentY,CurrentX+j] == player.disc){
                j++;
                
                if(j>=4){
                    Console.WriteLine("GAME OVER PLAYER {0} HAS WON ",player.id);
                    return WinStatus = "Win";
                    
                } 
                 
                 
            }
            i++;
            }
            return WinStatus;
           // Console.WriteLine("calculateWinHP");
            
        }
        public String CalculateWinVN(String [,]array,Player player,int CurrentX,int CurrentY){
            //Function to check if the LHS  to the current played point is a win
            int i =0, j = 0;
            while(i<7){
            if((CurrentY-j) <0 | (CurrentX +j) >6){
                 return WinStatus ="ContinuePlaying";
                 
            }
            
            if(array[CurrentY-j,CurrentX] == player.disc){
                
                //Console.WriteLine("Inside calculateWinVN {0}    {1}     {2}     {3} ",array[CurrentY-j,CurrentX],CurrentY-j,CurrentX,player.disc);
               j++;
                if(j>=4){
                Console.WriteLine("GAME OVER PLAYER {0} HAS WON ",player.id);
                  return WinStatus = "Win";
                   
                }
            } 
            i++;
            }
            return WinStatus;
            
        }
         public String CalculateWinVP(String [,]array,Player player,int CurrentX,int CurrentY){ 
            int i =0, j = 0;
            while(i<7){
                if((CurrentY +j) > 5){
                    return WinStatus ="ContinuePlaying";
                    
                }
                
                if(array[CurrentY+j,CurrentX] == player.disc){
                    
                   //Console.WriteLine("Inside calculateWinVN {0}    {1}     {2}     {2} ",array[CurrentY+j,CurrentX],CurrentY+j,CurrentX,player.disc);
                    j++;
                    if(j>=4){
                        Console.WriteLine("GAME OVER PLAYER {0} HAS WON ",player.id);
                       return WinStatus = "Win";
                    }
                }else {
                    WinStatus = "ContinuePlaying";
                    break;
                }
                i++;
            }
            return WinStatus;
        }
        public String CalculateWinDNN(String [,]array,Player player,int CurrentX,int CurrentY){
            
            //Function to check if the LHS diagonal to the current played point is a win
             int i =0, j = 0;
            while(i<7){
                    if((CurrentY-j) < 0 | (CurrentX-j < 0)){
                        return WinStatus = "ContinuePLaying";
                    
                    }
                    if(array[CurrentY-j,CurrentX-j] == player.disc){
                        j++;
                        if(j>=4){
                            Console.WriteLine("GAME OVER PLAYER {0} HAS WON ",player.id);
                            return WinStatus = "Win";
                        
                        }
                    }
                i++;
            }

             
            return WinStatus;
        }
        public String CalculateWinDPP(String [,]array,Player player,int CurrentX,int CurrentY){
            //Console.WriteLine("CalculateWINDPP");
            //Function to check if the RHS diagonal to the current played point is a win
             int i =0, j = 0;
              while(i<7){
            if((CurrentY+j) > 5 | (CurrentX+j) > 6){
                return WinStatus = "ContinuePLaying";
                 
            }
            if(array[CurrentY+j,CurrentX+j] == player.disc){
                
                 // Console.WriteLine("Inside calculateWinDPP {0}      {1} ",array[CurrentY+j,CurrentX+j],player.disc);
                  j++;
                if(j>=4){
                    Console.WriteLine("GAME OVER PLAYER {0} HAS WON ",player.id);
                    return WinStatus = "Win";
                    
                }

            }  
              i++; 
            }
           
            
              return WinStatus;
             
             // return WinStatus;
        }
        public String CalculateWinDPN(String [,]array,Player player,int CurrentX,int CurrentY){
           // Console.WriteLine("CalculateDPN");
             int i =0, j = 0;
            while(i<7){
                    if(CurrentY+j > 5 | CurrentX-j < 0){
                        return WinStatus = "ContinuePLaying";
                    
                    }
                    if(array[CurrentY+j,CurrentX-j] == player.disc){
                        
                       // Console.WriteLine("Inside calculateWinDPN {0}      {1} ",array[CurrentY+j,CurrentX-j],player.disc);
                        j++;
                        if(j>=4){
                            Console.WriteLine("GAME OVER PLAYER {0} HAS WON ",player.id);
                            return WinStatus = "Win";
                            
                        }
                    }
                i++;
            }
               
            return WinStatus;
        }
        public String CalculateWinDNP(String [,]array,Player player,int CurrentX,int CurrentY){
            //Function to check if the RHS diagonal to the current played point is a win
        // Console.WriteLine("CalculateWinDNP");
             int i =0, j = 0;
              while(i<7){
            if((CurrentY-j) < 0 | (CurrentX+j) > 6){
                return WinStatus = "ContinuePLaying";
                
            }
            if(array[CurrentY-j,CurrentX+j] == player.disc){
               
                 //Console.WriteLine("Inside calculateWinHN {0}      {1} ",array[CurrentY-j,CurrentX+j],player.disc);
                  j++;
                if(j>=4){
                    Console.WriteLine("GAME OVER PLAYER {0} HAS WON ",player.id);
                    return WinStatus = "Win";
                    
                }
            }
            i++;
            }
              
              return WinStatus;
        }

       

        public void Start(){
     
            
            GameSettings();
            if(GameMode == 1){
                Console.WriteLine("Currently we don't support AI");
                GameSettings();
            }else if(GameMode == 2){
                //show the game how it looks

                while(  !(CalculateWinHN(array,player,CurrentX,CurrentY) == "Win"  | CalculateWinHP(array,player,CurrentX,CurrentY) == "Win" | CalculateWinVP(array,player,CurrentX,CurrentY) == "Win" |
                
                        CalculateWinVN(array,player,CurrentX,CurrentY) == "Win" |
                        
                        CalculateWinDNN(array,player,CurrentX,CurrentY) == "Win" |
                        
                        CalculateWinDPP(array,player,CurrentX,CurrentY) == "Win" |
                        
                        CalculateWinDNP(array,player,CurrentX,CurrentY) == "Win" |
                        
                        CalculateWinDPN(array,player,CurrentX,CurrentY) == "Win" )  )
                    {

                    Console.WriteLine("Line 356 {0}",WinStatus);
                    DisplayGame();
                    Console.WriteLine("Enter  Player to go first 1 or 2");
                    string number = Console.ReadLine();
                    playernum = int.Parse(number);
                     if(playernum == 1)
                    {
                        player= player1;
                    }else if (playernum==2)
                    {
                        player=player2;
                    }
           
                    PlayGame(array);
            
                    
                } 
           
            
            }
            
            }
                
                
             
            }
        
            
    
    class display{
        static void Main(string[] args){
            
         Game game = new Game();
            game.Start();

            // Console.WriteLine("Would you like to Restart ?");
            // Console.WriteLine("Yes(1) No(0)");
            // String ? restart = Console.ReadLine();

            // if(restart == "1"){
            //     game.Start();
            // }else{
            //     Console.WriteLine("Good Bye!!!!!");
            // }
         
           
        }
        
    }
