import { AxiosError } from "axios";

/**
 * Actions Types
 */
export enum DefaultTypes {
    COURSE_PENDING = "@course/FETCH_COURSE_PENDING",
    COURSE_FAIL = "@course/FETCH_COURSE_FAILED",
};

/**
 * Actions format
 */

interface Pending {
    type: typeof DefaultTypes.COURSE_PENDING;
};

interface Rejected {
    type: typeof DefaultTypes.COURSE_FAIL;
    payload: any;
};


export type DefaultActions = Pending | Rejected;


