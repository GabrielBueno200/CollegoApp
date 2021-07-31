import { IUser } from "../../../../../models/users/user";
import { ISuccess } from "../../../models/success";

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
    payload: { user: IUser, successMessage : ISuccess }
};

export type RegisterActions = RegisteredUser