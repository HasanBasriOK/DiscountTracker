import React from 'react';
import axios from 'axios';
import { NativeModules, Platform } from 'react-native'

const apiBaseUrl = "http://192.168.1.103:5401/";

export function loginRequest(email, password, loginCallback) {
    console.log("Called login email:" + email + " password:" + password);

    var url = `${apiBaseUrl}auths/Login`;

    console.log("login url :" + url);
    console.log("password:" + password);

    try {
        var postData = {
            email: email,
            password: password
        }

        console.log("post data:" + JSON.stringify(postData));

        let axiosConfig = {
            headers: {
                'Content-Type': 'application/json;charset=UTF-8',
                "Access-Control-Allow-Origin": "*",
            }
        };
        axios.post(url, postData, axiosConfig)
            .then((res) => {
                console.log("istek gönderildi");
                if (res.status == 200)
                    loginCallback(res);
                else{
                    loginCallback(null, isErrorOccured);
                    console.log("İstek gönderilirken hata oluştu. Response :"+JSON.stringify(res));
                }
                    
            })
            .catch((err) => {
                console.log("AXIOS ERROR: ", JSON.stringify(err));
                loginCallback(null, isErrorOccured);
            });
    } catch (e) {
        console.error(JSON.stringify(e));
    }
}

