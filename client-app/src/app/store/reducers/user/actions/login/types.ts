import { IAuthenticationResult } from "../../../../../models/token/authResult";
import { IUser } from "../../../../../models/users/user";

/* Custom Payload Interface*/

export interface IUserAuth {
    tokens: IAuthenticationResult,
    user: IUser
};

/**
 * Actions Types
 */
 export enum LoginTypes {
    USER_LOGGEDIN_SUCCESS = "@user/USER_LOGGEDIN_SUCCESS",
};

/**
 * Actions format
 */
interface LoggedUser {
    type: typeof LoginTypes.USER_LOGGEDIN_SUCCESS,
    payload: IUser
};

export type LoginActions = LoggedUser