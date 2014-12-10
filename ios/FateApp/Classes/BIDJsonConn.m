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
-(id)init:(NSString *)initUrl{
    if(self=[super init]){
        self.mainUrl=initUrl;
    }
    return self;
}
-(void)PostdataByJsonAsy:(NSMutableDictionary *)datalist ExtensionUrl:(NSString *)inUrl{
    NSMutableDictionary *jsoninfo=[[NSMutableDictionary alloc]init];
    jsoninfo=datalist;
    NSError *error=nil;
    NSData *Jsondata=[NSJSONSerialization dataWithJSONObject:jsoninfo options:NSJSONWritingPrettyPrinted error:&error];
#ifdef DEBUG
    NSString *jsonText = [[NSString alloc] initWithData:Jsondata encoding:NSUTF8StringEncoding];
    NSLog(@"%@", jsonText);
#endif
    NSMutableData *multablejsondata=[NSMutableData dataWithData:Jsondata];
    NSMutableString *Str_serverUrl=[[NSMutableString alloc]initWithString:self.mainUrl];
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
/*
-(void)GetdataByJsonAsy:(NSMutableDictionary *)datalist ExtensionUrl:(NSString *) inUrl{
    NSMutableDictionary *jsoninfo=[[NSMutableDictionary alloc]init];
    jsoninfo=datalist;
    NSError *error=nil;
    NSData *Jsondata=[NSJSONSerialization dataWithJSONObject:jsoninfo options:NSJSONWritingPrettyPrinted error:&error];
    NSMutableData *multablejsondata=[NSMutableData dataWithData:Jsondata];
    NSMutableString *Str_serverUrl=[[NSMutableString alloc]initWithString:self.mainUrl];
    [Str_serverUrl appendString:inUrl];
    NSURL *url=[NSURL URLWithString:Str_serverUrl];
    ASIHTTPRequest *request=[ASIHTTPRequest requestWithURL:url];
    [request addRequestHeader:@"Content-Type" value:@"application/json; encoding=utf-8"];
    [request addRequestHeader:@"Accept" value:@"application/json"];
    [request setRequestMethod:@"Get"];
    [request setPostBody:multablejsondata];
    [request setDelegate:self];
    [request startAsynchronous];
}*/
-(void)GetdataByJsonAsy:(NSString *)inUrl{
    NSMutableString *str_serverUrl=[[NSMutableString alloc]initWithString:self.mainUrl];
    [str_serverUrl appendString:inUrl];
    NSURL *url=[NSURL URLWithString:str_serverUrl];
    ASIHTTPRequest *request=[ASIHTTPRequest requestWithURL:url];
    [request setDelegate:self];
    [request startAsynchronous];
}

-(NSDictionary *)GetdataByJsonSy:(NSString *)inUrl{
    NSMutableString *str_serverUrl=[[NSMutableString alloc]initWithString:self.mainUrl];
    [str_serverUrl appendString:inUrl];
    NSURL *url=[NSURL URLWithString:str_serverUrl];
    ASIHTTPRequest *request=[ASIHTTPRequest requestWithURL:url];
    [request startSynchronous];
    NSError *error = [request error];
    if (!error) {
        NSData *response = [request responseData];
        NSDictionary *data=[NSJSONSerialization JSONObjectWithData:response options:0 error:&error];
        return data;
    }
    NSLog(@"%@",error);
    return nil;
}
#pragma asiHttpRequest delegate
-(void)requestStarted:(ASIHTTPRequest *)request{
   
}
-(void)requestFinished:(ASIHTTPRequest *)request{
     NSLog(@"request success");
    NSError *error=[request error];
    if(!error){
        NSData *data=[request responseData];
        NSDictionary *requestdata=[NSJSONSerialization JSONObjectWithData:data options:0 error:&error];
        if(delegateforConn!=nil){
            if (requestdata==nil) {
                if([delegateforConn respondsToSelector:@selector(jsonRequestFinished)]){
                    [delegateforConn jsonRequestFinished];
                }
            }
            
            if([delegateforConn respondsToSelector:@selector(jsonRequestFinished:)]){
                [delegateforConn jsonRequestFinished:requestdata];
            }
    }
    }
}

-(void)requestFailed:(ASIHTTPRequest *)request{
     NSLog(@"request Failed");
    if(delegateforConn&&[delegateforConn respondsToSelector:@selector(josnRequestError)]){
        [delegateforConn josnRequestError];
       
    }
}
@end
