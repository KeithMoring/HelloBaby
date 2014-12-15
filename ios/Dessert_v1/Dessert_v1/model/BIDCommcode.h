//
//  BIDCommcode.h
//  FateApp
//
//  Created by fengxi on 14-11-8.
//  Copyright (c) 2014年 fengxi. All rights reserved.
//

#import <Foundation/Foundation.h>
#define KEY_LOGIN_NOT_PASS @"N"
#define KEY_LOGIN_PASS     @"P"
#define KEY_LOGIN_ERROR    @"E"
#define KEY_REGISTER_SUCCESS @"1"
#define KEY_REGISTER_ERROR  @"0"
#define  ServerUrl "http://192.168.211.1/ServiceForIOS.svc/"
#define PoserUrl "http://192.168.211.1/ServiceForIOSPoster.svc/"
//#define  ServerUrl "http://182.92.230.154:2122/ServiceForIOS.svc/"
//#define PoserUrl "http://182.92.230.154:2122/ServiceForIOSPoster.svc/"
#define getPosterResult @"GetPosterResult"
@interface BIDCommcode : NSObject{
    
}
@property  (atomic,copy) NSMutableString *User;
@end
