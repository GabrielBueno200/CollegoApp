import { IUser } from "../../../../models/users/user";
import { ISuccess } from "../../models/success";

export default interface IUserState {
    readonly data: IUser | {},
    readonly pending: boolean,
    readonly error?: any
    readonly successMessage?: ISuccess; 
};