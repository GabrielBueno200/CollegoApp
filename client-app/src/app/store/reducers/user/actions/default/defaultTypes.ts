/**
 * Actions Types
 */
 export enum DefaultTypes {
    USER_PENDING = "@user/FETCH_USER_PENDING",
    USER_FAIL    = "@user/FETCH_USER_FAILED",
    CLEAR_USER_ERRORS = "@user/CLEAR_USER_ERRORS"
};

/**
 * Actions format
 */

interface Pending {
    type: typeof DefaultTypes.USER_PENDING
};

interface Rejected {
    type: typeof DefaultTypes.USER_FAIL
    payload: any
};

interface ClearUserErrors {
    type: typeof DefaultTypes.CLEAR_USER_ERRORS
};


export type DefaultActions = Pending | Rejected | ClearUserErrors;