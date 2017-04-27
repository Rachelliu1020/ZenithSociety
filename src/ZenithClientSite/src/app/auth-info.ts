export class AuthInfo {

     static isAuth: boolean = false;

     static username: string = "Login";

     constructor() {
         if (localStorage.getItem("isAuth") 
                && localStorage.getItem("username")
                && localStorage.getItem("isAuth") == "true"
              ) {
             AuthInfo.isAuth = true;
             AuthInfo.username = localStorage.getItem("username");
         }
     }
}