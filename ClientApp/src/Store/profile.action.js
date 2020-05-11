export function LOG_IN(profile){
    console.log(profile)
    return {type: LOG_IN, profile}
}
export function LOG_OUT(){
    return {type: LOG_OUT}
}

export function UPDATE_PROFILE(updatedProfile){
    return {type: UPDATE_PROFILE, updatedProfile}
}