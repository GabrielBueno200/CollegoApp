import { AxiosError } from "axios";
import { DefaultTypes, DefaultActions } from "./defaultTypes";

export const requestingUniversity = (): DefaultActions => ({
    type: DefaultTypes.UNIVERSITY_PENDING
});

export const failedRequestingUniversity = (error: AxiosError): DefaultActions => ({
    type: DefaultTypes.UNIVERSITY_FAIL,
    payload: error
});
