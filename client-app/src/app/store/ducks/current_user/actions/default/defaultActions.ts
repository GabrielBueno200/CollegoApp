import { IDefaultUserTypes, DefaultUserActions, IUserError } from "./defaultTypes";

export const requestingUser = ():DefaultUserActions=> ({
    type: IDefaultUserTypes.USER_PENDING,
});

export const failedRequestingUser = (error: IUserError):DefaultUserActions=> ({
    type: IDefaultUserTypes.USER_FAIL,
    payload: error
});