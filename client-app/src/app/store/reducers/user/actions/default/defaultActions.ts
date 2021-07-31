import { AxiosError } from "axios";
import { DefaultTypes, DefaultActions } from "./defaultTypes";

export const requestingUser = (): DefaultActions=> ({
    type: DefaultTypes.USER_PENDING,
});

export const failedRequestingUser = (error: AxiosError): DefaultActions=> ({
    type: DefaultTypes.USER_FAIL,
    payload: error
});

export const clearUserErrors = (): DefaultActions => ({
    type: DefaultTypes.CLEAR_USER_ERRORS
});