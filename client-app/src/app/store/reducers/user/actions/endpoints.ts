import { default as api } from '../../../../api';
import { ITokens } from '../../../../models/token/token';
import { IUserLogin } from '../../../../models/users/login';
import { IUserRegister } from '../../../../models/users/register';
import { IUser } from "../../../../models/users/user";

export enum Endpoints {
    signIn = "Account/login",
    signUp = "Account/create",
    logout = "Profile/logout",
    listUser = "Profile/list"
}

interface IUserRequester {
    signIn: (user:IUserLogin) => Promise<IUser>;
    signUp: (user:IUserRegister) => Promise<IUser>;
    logout: (tokens:ITokens) => void;
    listUser: () => Promise<IUser>;
    //updateUser: (user:IUser) => void,
    //deleteUser: () => void,
};

const ApiRequest : IUserRequester = {
    signIn: (user:IUserLogin) => api.post<IUserLogin, IUser>(Endpoints.signIn, user),
    signUp: (user:IUserRegister) => api.post<IUserRegister, IUser>(Endpoints.signUp, user),
    logout: (tokens:ITokens) => api.post<ITokens>(Endpoints.logout, tokens),
    listUser: () => api.get<IUser>(Endpoints.listUser),
};

export default ApiRequest;
