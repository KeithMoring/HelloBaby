//
//  BIDViewController.h
//  FateApp
//
//  Created by fengxi on 14-10-27.
//  Copyright (c) 2014年 fengxi. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface BIDViewController : UIViewController
@property (weak, nonatomic) IBOutlet UILabel *lable;
@property (weak, nonatomic) IBOutlet UIButton *TestWcf;
- (IBAction)TestforWcf:(id)sender;
@property (weak, nonatomic) IBOutlet UILabel *WcfTestLable;
-(void)Createuser;
@end
