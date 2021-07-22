import { IError } from "../../../../../models/errors/errors";
import { DefaultTypes, DefaultActions } from "./defaultTypes";

export const requestingUser = (): DefaultActions=> ({
    type: DefaultTypes.USER_PENDING,
});

export const failedRequestingUser = (error: IError): DefaultActions=> ({
    type: DefaultTypes.USER_FAIL,
    payload: error
});