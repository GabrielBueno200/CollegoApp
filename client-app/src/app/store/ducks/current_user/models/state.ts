import { IUser } from "../../../../models/user";
import { IUserError } from "../actions/default/defaultTypes";

export interface IUserState {
    data: IUser | {},
    pending: boolean,
    error?: IUserError
}