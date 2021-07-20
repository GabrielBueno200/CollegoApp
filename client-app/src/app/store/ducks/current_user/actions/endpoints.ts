import { default as api } from '../../../../api';
import { IUser } from "../../../../models/user";

export enum Endpoints {
    listUser = "Account/list"
}

interface IUserRequester {
    listUser: () => Promise<IUser>
    //createUser: (user:IUser) => void,
    //updateUser: (user:IUser) => void,
    //deleteUser: () => void,
};

const ApiRequest : IUserRequester = {
    listUser: () => api.get<IUser>(Endpoints.listUser)
};

export default ApiRequest;