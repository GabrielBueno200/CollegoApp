import { IUser } from "../../../../../models/users/user";

/**
 * Actions Types
 */
 export enum RegisterTypes {
    USER_REGISTERED_SUCCESS = "@user/USER_LOGGEDIN_SUCCESS",
};

/**
 * Actions format
 */
interface RegisteredUser {
    type: typeof RegisterTypes.USER_REGISTERED_SUCCESS,
    payload?: IUser
};

export type RegisterActions = RegisteredUser