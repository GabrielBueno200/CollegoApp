import { DefaultTypes, DefaultActions, IUserError } from "./defaultTypes";

export const requestingUser = (): DefaultActions=> ({
    type: DefaultTypes.USER_PENDING,
});

export const failedRequestingUser = (error: IUserError): DefaultActions=> ({
    type: DefaultTypes.USER_FAIL,
    payload: error
});