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
    payload: any
}


export type DefaultActions = Pending | Rejected