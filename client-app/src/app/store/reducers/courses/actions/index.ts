import { DefaultActions, DefaultTypes } from "./default/defaultTypes";
import { LoadActions, LoadTypes } from "./load/types";

export type CourseActions = 
    DefaultActions 
  | LoadActions;
  
export const CourseTypes = { 
    ... DefaultTypes,
    ... LoadTypes
};