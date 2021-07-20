import { IUser } from "../../../../../models/user";

/**
 * Actions Types
 */
 export enum ILoadUserTypes {
    USER_SUCCESS = "@user/LOAD_USER_SUCCESS",
};

/**
 * Actions format
 */
interface LoadedUser {
    type: typeof ILoadUserTypes.USER_SUCCESS
    payload: IUser
};

export type LoadUserActions = LoadedUser