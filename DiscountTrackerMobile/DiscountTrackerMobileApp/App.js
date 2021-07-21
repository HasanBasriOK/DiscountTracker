/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 * @flow strict-local
 */

import React from 'react';
import {
  SafeAreaView,
  ScrollView,
  StatusBar,
  StyleSheet,
  Text,
  useColorScheme,
  View,
} from 'react-native';

import {
  Colors,
  DebugInstructions,
  Header,
  LearnMoreLinks,
  ReloadInstructions,
} from 'react-native/Libraries/NewAppScreen';
import LoginScreen from "../DiscountTrackerMobileApp/src/screens/Login/index"
import MainPage from "../DiscountTrackerMobileApp/src/screens/MainPage/index"
import { NavigationContainer } from '@react-navigation/native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

const Tab = createBottomTabNavigator();

function HomeTabs({ navigation, route}) {
  React.useLayoutEffect(() => {
    navigation.setOptions({ headerTitle: getHeaderTitle(route) });
  }, [navigation, route]);

  return (
    <Tab.Navigator screenOptions={({ route }) => ({
      tabBarIcon: ({ focused, color, size }) => {
        let iconName;

        if (route.name === 'MainPage') {
          iconName = focused ? 'home' : 'home-outline';
        } else if (route.name === 'ListScreen') {
          iconName = focused ? 'list' : 'list-outline';
        }
        else if (route.name == 'SettingsScreen') {
          iconName = focused ? 'settings' : 'settings-outline';
        }
        return <Ionicons name={iconName} size={size} color={color} />;
      },
    })}
      tabBarOptions={{
        showLabel: false,
        activeTintColor: '#ffffff',
        inactiveTintColor: '#ffffff',
        keyboardHidesTabBar: true,
        style: { position: 'absolute', backgroundColor: Colors.tabBarColor, height: 65 },
      }}>
      <Tab.Screen name="HomeScreen" children={()=><MainPage changeLang={changeLanguage}/>}/>
      {/* <Tab.Screen name="ListScreen" children={()=><ListScreen changeLang={changeLanguage}/>}/>
      <Tab.Screen name="SettingsScreen" children={()=><SettingsScreen changeLang={changeLanguage}/>}/> */}

    </Tab.Navigator>
  );
}

function getHeaderTitle(route) {

  const routeName = getFocusedRouteNameFromRoute(route) ?? 'HomeScreen';
  switch (routeName) {
    case 'HomeScreen':
      return '';
    case 'ListScreen':
      return '';
    case 'SettingsScreen':
      return '';

  }
}
const Stack = createStackNavigator();


const App = () => {
  const isDarkMode = useColorScheme() === 'dark';

  const backgroundStyle = {
    backgroundColor: isDarkMode ? Colors.darker : Colors.lighter,
  };

  return (
    <NavigationContainer>
    <Stack.Navigator initialRouteName="Login" title="" screenOptions={{ headerShown: false }} >
      <Stack.Screen name="Login" component={LoginScreen} />
      <Stack.Screen name="HomeScreen" component={HomeTabs}/>
    </Stack.Navigator>
    <Toast ref={(ref) => global['toast'] = ref} />
  </NavigationContainer>
  );
};

export default App;
