import React, { useEffect, useState } from 'react';
import Icon from 'react-native-vector-icons/FontAwesome';
import {
    StyleSheet,
    Text,
    View,
    Dimensions,
    Keyboard
} from 'react-native';
import { Input, CheckBox, Button } from 'react-native-elements';
import { useNavigation } from '@react-navigation/native';
import md5 from "react-native-md5";
import loginRequest from "../../helpers/userApiHelper"
import { openDatabase } from 'react-native-sqlite-storage';
import { createSemanticDiagnosticsBuilderProgram } from 'typescript';

var db = openDatabase({ name: 'SchoolDatabase.db' });

const LoginScreen = () => {
    const navigation = useNavigation();

    //#region Constructors

    useEffect(() => {
        //check user data from sqlite database
        //is exist any user play login process
        //is not exist any user dont do anything
        checkUserForFirstLoad();
    }, []);

    //#endregion

    //#region States 
    const [rememberMe, setRememberMe] = useState();
    const [email, setEmail] = useState();
    const [password, setPassword] = useState();
    //#endregion

    //#region Control Events

    const rememberMeClick = () => {
        console.log("Remember me click... Value :" + rememberMe);
        if (rememberMe == undefined || rememberMe == null || !rememberMe) {
            setRememberMe(true);
        }
        else
            setRememberMe(false);
    }


    const loginClick = () => {
        Keyboard.dismiss();
        if (!email) {
            alert("Email boş olamaz!");
        }
        else if (!password) {
            alert("Şifre boş olamaz!");
        }
        else {
            var encryptedPassword = md5.str_md5(password.trim());
            var username = email.trim();

            loginRequest(username, encryptedPassword, loginCallback);
        }
    }
    // this.props.navigation.navigate('HomeScreen');

    //#endregion

    //#region Custom Functions 

    const loginCallback = (response, isErrorOccured = false) => {
        if (!isErrorOccured) {
            if (rememberMe) {
                saveUserToSqlite();
            }
            else {
                this.props.navigation.navigate("MainPage");
            }
        }
        else {
            alert("İşlem gerçekleştirilirken hata oluştu");
        }
    }

    const genericError = (e) => {
        console.warn('Error: ' + JSON.stringify(e));
    };

    const afterRunQuerySuccess = (tx, res) => {
        console.log("tx : " + JSON.stringify(tx));
        console.log("res:" + JSON.stringify(res));
        // if(res.rows.length >0 ){
        //     for (let i = 0; i < res.rows.length; i++) {
        //         var item = res.rows.item(i);
        //         console.log(item);

        //       }
        // }
    }

    const afterRunQueryError = (error) => {
        console.log("error :" + JSON.stringify(error));
    }

    const dbOpened = () => {
        console.log('Creating table...');
        db.transaction((txn) => {
            txn.executeSql(
                `CREATE TABLE IF NOT EXISTS UserInformation(
                EMAIL           TEXT    NOT NULL,
                PASSWORD            INT     NOT NULL
              );`, [], afterRunQuerySuccess, afterRunQueryError
            )
        })
    }

    const checkUserExistSuccess = (tx, res) => {
        if (res.rows.length > 0) {
            //There is a user data in table
            let query = `UPDATE UserInformation SET EMAIL='${email}',PASSWORD='${password}';`
            console.log("query" + query);
            db.transaction((txn) => {
                txn.executeSql(
                    query, [], afterRunQuerySuccess, afterRunQueryError
                )
            });
        }
        else {
            let query = "INSERT INTO UserInformation VALUES('" + username + "','" + password + "');"
            console.log("query" + query);
            db.transaction((txn) => {
                txn.executeSql(
                    query, [], afterRunQuerySuccess, afterRunQueryError
                )
            });
        }

        this.props.navigation.navigate("MainPage");
    }

    const checkUserExistSuccessForFirstLoad = (tx, res) => {
        if (res.rows.length > 0) {
            let user = res.rows.item(0);
            setEmail(user.EMAIL);
            setPassword(user.PASSWORD);
            loginClick();
        }
    }

    const checkUserForFirstLoad = () => {
        console.log(`getting user by username and password. username : ${email} password: ${password}`);
        db.transaction((txn) => {
            txn.executeSql(`SELECT * FROM UserInformation;`, [], checkUserExistSuccessForFirstLoad, afterRunQueryError);
        });
    }

    const saveUserToSqlite = () => {

        //Check user exist
        console.log(`getting user by username and password. username : ${email} password: ${password}`);
        db.transaction((txn) => {
            txn.executeSql(`SELECT * FROM UserInformation;`, [], checkUserExistSuccess, afterRunQueryError);
        });

        console.log('Inserting records...' + username + "-----" + password);
        console.log("db" + JSON.stringify(db));

    }

    const getRecord = (username, password) => {
        console.log('getRecord...');
        db.transaction((txn) => {
            txn.executeSql(`SELECT * FROM UserInformation WHERE EMAIL='${username}' AND  PASSWORD='${password}';`, [], afterRunQuerySuccess, afterRunQueryError);
        });
    }

    //#endregion

    //#region View
    return (
        <View
            style={styles.rootView}
            contentInsetAdjustmentBehavior="automatic">
            <Input
                style={styles.input}
                placeholder='E-mail'
                leftIcon={
                    <Icon
                        name='user'
                        size={21}
                        color='black'
                    />
                }
                keyboardType='email-address' />
            <Input style={styles.input} placeholder="Password"
                leftIcon={
                    <Icon name='unlock' size={21} color='black' />
                }
                secureTextEntry={true} />
            <CheckBox
                style={styles.checkbox}
                title='Beni Hatırla'
                checked={rememberMe}
                onIconPress={() => rememberMeClick()} />

            <Text style={styles.text}>
                Hala üye değil misin, hemen <Text style={styles.blueText}> Üye ol!</Text>
            </Text>

            <View style={styles.loginButton}>
                <Button
                    icon={
                        <Icon name="arrow-right" size={15} color="white" />
                    }
                    title="Giriş Yap"
                    onPress={() => insertUserInfo('aaaa', 'bbbb')}
                />
            </View>

            <View style={styles.loginButton}>
                <Button
                    icon={
                        <Icon name="arrow-right" size={15} color="white" />
                    }
                    title="Getir"
                    onPress={() => getRecord('aaaa', 'bbbcb')}
                />
            </View>
        </View>
    );

    //#endregion
};

//#region Styles
const styles = StyleSheet.create({
    blueText: {
        color: 'blue'
    },
    input: {
        marginTop: Dimensions.get('window').height * 0.01
    },
    loginButton: {
        marginTop: Dimensions.get('window').height * 0.05,
        marginLeft: '10%',
        width: '80%',

    },
    text: {
        width: '80%',
        marginLeft: '20%',
        marginTop: Dimensions.get('window').height * 0.05,
    },
    checkbox: {
        marginTop: Dimensions.get('window').height * 0.1,
    },
    rootView: {
        width: '100%'
    }
});
//#endregion

export default LoginScreen;