import { IUniversity } from "../../../../../models/universities/university";

/**
 * Action Types
 */
export enum LoadTypes {
    GET_UNIVERSITY_BY_ACRONYM_SUCCESS = "@university/GET_UNIVERSITY_BY_ACRONYM_SUCCESS"
};

/**
 * Action formats
 */
export interface LoadedUniversity {
    type: typeof LoadTypes.GET_UNIVERSITY_BY_ACRONYM_SUCCESS;
    payload: IUniversity
};


export type LoadActions = LoadedUniversity;