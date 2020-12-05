using System;

namespace RavenclawSecondPracticeTask
{
    class Data
    {
        private int maxAdress;     
        private User[] Users = new User[1];

        public Data()
        {
            maxAdress = 0;
        }

        private void changeName(int adress, string name)
        {
            Console.WriteLine("Username in " + adress + " adress changed from " + Users[adress].getUsername() + " to " + name);
            Users[adress].setUsername(name);          
            Users[adress].setUsername(name);
        }

        private void setMaxAdress(int adress)
        {
            maxAdress = adress;        
            Array.Resize(ref Users, adress + 1);
        }

        public string getName(int adress)
        {
            if (adress <= maxAdress && Users[adress] != null)
            {
                Console.WriteLine("In adress " + adress + " name of user is " + Users[adress].getUsername());
                return Users[adress].getUsername();
            }
            else
            {
                Console.WriteLine("Eror invalid adress");
                return "";
            }                      
        }

        public void Update(int adress , int newAdress , string newName)
        {
            if (adress >= 0 && adress >= 0 && newAdress >= 0)
            {
                if (newAdress <= maxAdress && Users[newAdress] != null)
                {
                    Console.WriteLine("Eror in this adress already has user");
                }
                else
                if (Users[adress] == null)
                {
                    Console.WriteLine("Eror in this adress didn't create user");
                }
                else
                {
                    if (adress != newAdress)
                    {
                        if (newAdress > maxAdress)
                            setMaxAdress(newAdress);

                        Users[newAdress] = Users[adress];
                                            
                        Users[newAdress].setUsername(Users[adress].getUsername());
                        Users[adress] = null;
                                           
                        Console.WriteLine("Changed User's adress " + adress + " with username " + Users[newAdress].getUsername() + " to new adress " + newAdress);

                    }

                    if (Users[newAdress].getUsername() != newName)
                    {
                       changeName(newAdress, newName);
                    }

                }
            }
            else
                Console.WriteLine("Eror invalid adress");      
        }

        private int getNextAdress()
        {
            int ad = 0;
            bool t = false;

            for (int i = 0; i <= maxAdress; i++)
                if (Users[i] == null)
                {
                    t = true;
                    ad = i;
                    break;
                }
            if (t == false)
                ad = maxAdress + 1;

            return ad;
        }

        public int createUser()
        {
            int aUser , k;

            if (getNextAdress() > maxAdress)
            {
                aUser = getNextAdress();
                Array.Resize(ref Users, aUser + 1);
                maxAdress++;
            }
            else
                aUser = getNextAdress();

            Console.WriteLine("Created User in " + aUser + " adress");         

            Users[aUser] = new User();

            Users[aUser].setUsername("New user");

            return aUser;
        }
    }

    class User
    {
        private string _username;
        private int _adress;

        public User() {

        }
        
        public void setUsername(string username)
        {       
            _username = username;                      
        }

        public string getUsername()
        {
            Console.WriteLine("Your username - " + _username);
            return _username;
        }

        public int getAdress()
        {
            Console.WriteLine("Your adress - " + _adress);
            return _adress;
        }
        public void setAdress(int adress)
        {
            if (adress >= 0)
            {
                _adress = adress;
                Console.WriteLine("Aress changed to " + _adress);
            }
            else
                Console.WriteLine("Error invalid adress");
        }
    }

    class Program
    {
        static Data data = new Data();
        static void Main(string[] args)
        {
            data.createUser();
            data.createUser();
            data.createUser();
            data.Update(1, 5, "Vlad");
            data.Update(2, 4, "Max");
        }
    }
}
