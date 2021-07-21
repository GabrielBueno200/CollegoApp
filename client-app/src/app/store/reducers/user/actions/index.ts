import { DefaultActions, DefaultTypes } from "./default/defaultTypes";
import { LoadTypes, LoadActions } from "./load/types";
import { LoginTypes, LoginActions } from "./login/types";
import { LogoutActions, LogoutTypes } from "./logout/types";
import { RegisterTypes, RegisterActions } from "./register/types";


export const UserTypes = { 
    ...DefaultTypes, 
    ...LoadTypes, 
    ...LoginTypes, 
    ...LogoutTypes,
    ...RegisterTypes 
};

export type UserActions = 
    DefaultActions | 
    LoadActions    | 
    LoginActions   |
    LogoutActions  | 
    RegisterActions;