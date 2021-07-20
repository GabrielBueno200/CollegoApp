import { ILoadUserTypes, LoadUserActions } from "../load/types"

/**
 * Actions Types
 */
 export enum IDefaultUserTypes {
    USER_PENDING = "@user/FETCH_USER_PENDING",
    USER_FAIL    = "@user/FETCH_USER_FAILED"
};

/**
 * Actions format
 */

interface Pending {
    type: typeof IDefaultUserTypes.USER_PENDING
}

interface Rejected {
    type: typeof IDefaultUserTypes.USER_FAIL
    payload: IUserError
}

/**
 * Action rejected model
 */

export interface IUserError {
    messages: string[] | string
};


export type DefaultUserActions = 
      Pending
    | Rejected