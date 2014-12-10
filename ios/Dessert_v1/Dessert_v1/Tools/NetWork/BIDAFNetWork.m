//
//  BIDAFNetWork.m
//  Dessert_v1
//
//  Created by fengxi on 14-12-6.
//  Copyright (c) 2014年 KeithMorning. All rights reserved.
//

#import "BIDAFNetWork.h"

@implementation BIDAFNetWork
+(void)PostDataFromNet:(NSString *)urlstring InputParas:(NSDictionary *)inputParas success:(void(^)(NSDictionary * resultDic))success failure:(void(^)(NSError *error))failure{
    AFHTTPRequestOperationManager *requestMange=[AFHTTPRequestOperationManager manager];
    requestMange.requestSerializer=[AFJSONRequestSerializer serializer];
    [requestMange POST:urlstring parameters:inputParas success:^(AFHTTPRequestOperation *operation, id responseObject) {
        if (success) {
            success(responseObject);
        }
        
    } failure:^(AFHTTPRequestOperation *operation, NSError *error) {
        failure(error);
    }];

}
+(void)GetDataFromNet:(NSString *)urlstring success:(void (^)(NSDictionary *))success failure:(void (^)(NSError *))failure{
    AFHTTPRequestOperationManager *requestManger=[AFHTTPRequestOperationManager manager];
    [requestManger GET:urlstring parameters:nil success:^(AFHTTPRequestOperation *operation, id responseObject) {
        if (success) {
            success(responseObject);
        }
    } failure:^(AFHTTPRequestOperation *operation, NSError *error) {
           failure(error);
    }];
}
@end
