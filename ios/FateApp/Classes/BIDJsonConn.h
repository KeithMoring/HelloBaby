//
//  BIDJsonConn.h
//  FateApp
//
//  Created by fengxi on 14-11-1.
//  Copyright (c) 2014年 fengxi. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "ASIHTTPRequest.h"
#define  ServerUrl "http://192.168.211.1/ServiceForIOS.svc/"
@protocol JsonConnDeleage<NSObject>
@optional
-(void)jsonRequestFinished;
-(void)josnRequestError;
@end;
@interface BIDJsonConn : NSObject<ASIHTTPRequestDelegate>
@property(assign,nonatomic) id<JsonConnDeleage>delegateforConn;
-(void)PostdataByJsonAsy:(NSMutableDictionary *)datalist ExtensionUrl:(NSString *) inUrl;
@end
