/**
 * Actions Types
 */
 export enum DefaultTypes {
    USER_PENDING = "@user/FETCH_USER_PENDING",
    USER_FAIL    = "@user/FETCH_USER_FAILED"
};

/**
 * Actions format
 */

interface Pending {
    type: typeof DefaultTypes.USER_PENDING
}

interface Rejected {
    type: typeof DefaultTypes.USER_FAIL
    payload: IUserError
}

/**
 * Action rejected model
 */

export interface IUserError {
    messages: string[] | string
};


export type DefaultActions = Pending | Rejected