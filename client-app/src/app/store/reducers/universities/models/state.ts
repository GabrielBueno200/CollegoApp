import { IUniversity } from "../../../../models/universities/university";

export default interface IUniversityState {
    readonly data: IUniversity[] | [],
    readonly pending: boolean,
    readonly error?: any
};