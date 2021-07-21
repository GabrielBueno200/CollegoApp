import { IUser } from "../../../../models/users/user";
import { IUserError } from "../actions/default/defaultTypes";

export default interface IUserState {
    readonly data: IUser | {},
    readonly pending: boolean,
    readonly error?: IUserError
};