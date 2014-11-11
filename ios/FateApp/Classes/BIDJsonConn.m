//
//  BIDJsonConn.m
//  FateApp
//
//  Created by fengxi on 14-11-1.
//  Copyright (c) 2014年 fengxi. All rights reserved.
//

#import "BIDJsonConn.h"


@implementation BIDJsonConn
@synthesize delegateforConn;
-(void)PostdataByJsonAsy:(NSMutableDictionary *)datalist ExtensionUrl:(NSString *)inUrl{
    NSMutableDictionary *jsoninfo=[[NSMutableDictionary alloc]init];
    jsoninfo=datalist;
    NSError *error=nil;
    NSData *Jsondata=[NSJSONSerialization dataWithJSONObject:jsoninfo options:NSJSONWritingPrettyPrinted error:&error];
    NSMutableData *multablejsondata=[NSMutableData dataWithData:Jsondata];
    NSMutableString *Str_serverUrl=[[NSMutableString alloc]initWithString:@ServerUrl];
    [Str_serverUrl appendString:inUrl];
    NSURL *url=[NSURL URLWithString:Str_serverUrl];
    ASIHTTPRequest *request=[ASIHTTPRequest requestWithURL:url];
    [request addRequestHeader:@"Content-Type" value:@"application/json; encoding=utf-8"];
    [request addRequestHeader:@"Accept" value:@"application/json"];
    [request setRequestMethod:@"POST"];
    [request setPostBody:multablejsondata];
    [request setDelegate:self];
    [request startAsynchronous];
}
#pragma asiHttpRequest delegate
-(void)requestFinished:(ASIHTTPRequest *)request{
    if(delegateforConn!=nil){
        if([delegateforConn respondsToSelector:@selector(jsonRequestFinished)]){
            [delegateforConn jsonRequestFinished];
        }
        
    }
}

-(void)requestFailed:(ASIHTTPRequest *)request{
    if(delegateforConn&&[delegateforConn respondsToSelector:@selector(josnRequestError)]){
        [delegateforConn josnRequestError];
    }
}
@end
