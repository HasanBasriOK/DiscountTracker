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
import SQLite, { SQLiteDatabase, ResultSet } from 'react-native-sqlite-storage'
import { createSemanticDiagnosticsBuilderProgram } from 'typescript';


const LoginScreen = () => {
    let db = SQLiteDatabase();
    const navigation = useNavigation();

    //-----------------------------Constructors Start------------------------------------

    useEffect(() => {
        SQLite.enablePromise(true);
        SQLite.openDatabase({ name: 'discountTracker.db', location: 'Documents' })
            .then(dbRes => { db = dbRes; dbOpened(); })
            .catch(e => genericError(e));
    }, []);

    //-----------------------------Constructors End------------------------------------



    //-----------------------------States Start-------------------------------------
    const [rememberMe, setRememberMe] = useState(false);
    const [email, setEmail] = useState();
    const [password, setPassword] = useState();
    //-----------------------------States End----------------------------------------




    //-----------------------------Control Events Start------------------------------

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

            loginRequest(username, password, loginCallback);

            //Call Api
        }
    }
    // this.props.navigation.navigate('HomeScreen');

    //-----------------------------Control Events End--------------------------------




    //-----------------------------Custom Functions Start----------------------------

    const loginCallback = (response, isErrorOccured = false) => {
        if (!isErrorOccured) {
            if (rememberMe) {

            }

            navigation.navigate("MainPage");
        }
        else {
            alert("İşlem gerçekleştirilirken hata oluştu");
        }
    }

    const genericError = (e) => {
        console.warn('Error: ' + JSON.stringify(e));
      };

    const dbOpened = () => {
        console.log('Creating table...');
        db.executeSql(
            `CREATE TABLE UserInformation(
            EMAIL           TEXT    NOT NULL,
            PASSWORD            INT     NOT NULL
          );`,
        )
            .then(result => console.log("Table Created"))
            .catch(e => {
                genericError(e);
            });
    }

    const insertUserInfo = (username,password) => {
        console.log('Inserting records...');
        db.executeSql(
            `INSERT INTO UserInformation VALUES('${username}','${password}')
          ;`,
        )
            .then(result => recordsInserted(result))
            .catch(e => {
                genericError(e);
            });
    };

    const dropTable = (db) => {
        console.log('Dropping table...');
        db.executeSql(`DROP TABLE EMPLOYEE;`)
            .then(result => dbOpened())
            .catch(e => {
                genericError(e);
            });
    };

    const getRecord = (username,password) => {
        console.log('Selecting records...');
        db.executeSql(`SELECT * FROM EMPLOYEE WHERE ;`)
          .then(result => {

          })
          .catch(e => {
            genericError(e);
          });
    }

    //-----------------------------Custom Functions End------------------------------





    //----------------------------View Start--------------------------------------
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
                onIconPress={rememberMeClick()} />

            <Text style={styles.text}>
                Hala üye değil misin, hemen <Text style={styles.blueText}> Üye ol!</Text>
            </Text>

            <View style={styles.loginButton}>
                <Button
                    icon={
                        <Icon name="arrow-right" size={15} color="white" />
                    }
                    title="Giriş Yap"
                    onPress={() => loginClick()}
                />
            </View>
        </View>
    );

    //------------------------------View End------------------------------------
};

//---------------------------------Styles Start-----------------------------------
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
//---------------------------------Styles End-----------------------------------

export default LoginScreen;