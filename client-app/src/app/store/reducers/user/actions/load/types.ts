import { IUser } from "../../../../../models/users/user";

/**
 * Actions Types
 */
 export enum LoadTypes {
    LOADED_USER_SUCCESS = "@user/LOAD_USER_SUCCESS",
};

/**
 * Actions format
 */
interface LoadedUser {
    type: typeof LoadTypes.LOADED_USER_SUCCESS
    payload: IUser
};

export type LoadActions = LoadedUser