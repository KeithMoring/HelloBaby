//
//  BIDJsonConn.h
//  FateApp
//
//  Created by fengxi on 14-11-1.
//  Copyright (c) 2014年 fengxi. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "ASIHTTPRequest.h"


@protocol JsonConnDeleage<NSObject>
@optional
-(void)jsonRequestFinished;
-(void)jsonRequestFinished:(NSDictionary *) requestdata;
-(void)josnRequestError;
@end;
@interface BIDJsonConn : NSObject<ASIHTTPRequestDelegate>
@property(assign,nonatomic) id<JsonConnDeleage>delegateforConn;
@property(nonatomic,copy) NSString *mainUrl;
-(void)PostdataByJsonAsy:(NSMutableDictionary *)datalist ExtensionUrl:(NSString *) inUrl;
-(void)GetdataByJsonAsy:(NSString *)inUrl;
-(NSDictionary *)GetdataByJsonSy:(NSString *)inUrl;
-(id)init:(NSString *)initUrl;
@end
