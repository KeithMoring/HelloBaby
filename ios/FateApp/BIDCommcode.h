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
#define  ServerUrl "http://192.168.211.1/ServiceForIOS.svc/"
#define PoserUrl "http://192.168.211.1/ServiceForIOSPoster.svc/"

@interface BIDCommcode : NSObject{
    
}
@property  (atomic,copy) NSMutableString *User;
@end
