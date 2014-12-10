//
//  BIDCommeMeathod.m
//  FateApp
//
//  Created by fengxi on 14-12-1.
//  Copyright (c) 2014年 fengxi. All rights reserved.
//

#import "BIDCommeMeathod.h"

@implementation BIDCommeMeathod
static NSUserDefaults *UserDef;

-(id)init{
    if (self=[super init]) {
        UserDef=[NSUserDefaults standardUserDefaults];
    }
    return self;
}
+(NSString *)getuserName{
    UserDef=[NSUserDefaults standardUserDefaults];
    NSString *username= [UserDef objectForKey:@"username"];
    return username;
}
+(NSString *)getUserIDByLocal{
    UserDef=[NSUserDefaults standardUserDefaults];
    NSString *id= [UserDef objectForKey:@"UserID"];
    return id;
    
}

@end
