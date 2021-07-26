import { DefaultActions, DefaultTypes } from "./default/defaultTypes";
import { LoadActions, LoadTypes } from "./findByAcronym/types";

export type UniversityActions = 
    DefaultActions 
  | LoadActions;
  
export const UniversityTypes = { 
    ... DefaultTypes,
    ... LoadTypes
};