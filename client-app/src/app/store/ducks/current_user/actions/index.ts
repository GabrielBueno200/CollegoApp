import { DefaultUserActions, IDefaultUserTypes } from "./default/defaultTypes";
import { ILoadUserTypes, LoadUserActions } from "./load/types";

export type UserTypes = IDefaultUserTypes | ILoadUserTypes

export type UserActions = DefaultUserActions | LoadUserActions