import { IUser } from "../../../../../models/users/user";

/**
 * Actions Types
 */
 export enum LogoutTypes {
    USER_EXIT_SUCCESS = "@user/USER_EXIT_SUCCESS",
};

/**
 * Actions format
 */
interface UserExit {
    type: typeof LogoutTypes.USER_EXIT_SUCCESS,
};

export type LogoutActions = UserExit