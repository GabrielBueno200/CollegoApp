import { AxiosError } from "axios";
import { DefaultTypes, DefaultActions } from "./defaultTypes";

export const requestingCourse = (): DefaultActions => ({
    type: DefaultTypes.COURSE_PENDING
});

export const failedRequestingCourse = (error: AxiosError): DefaultActions => ({
    type: DefaultTypes.COURSE_FAIL,
    payload: error
});
