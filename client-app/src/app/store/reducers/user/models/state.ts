import { IUser } from "../../../../models/users/user";

export default interface IUserState {
    readonly data: IUser | {},
    readonly pending: boolean,
    readonly error?: any
};