import { AxiosError } from "axios";

/**
 * Actions Types
 */
export enum DefaultTypes {
    UNIVERSITY_PENDING = "@university/FETCH_UNIVERSITY_PENDING",
    UNIVERSITY_FAIL = "@university/FETCH_UNIVERSITY_FAILED",
};

/**
 * Actions format
 */

interface Pending {
    type: typeof DefaultTypes.UNIVERSITY_PENDING;
};

interface Rejected {
    type: typeof DefaultTypes.UNIVERSITY_FAIL;
    payload: any;
};


export type DefaultActions = Pending | Rejected;


